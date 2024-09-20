import json
from datetime import datetime
import string, random
from django.db import IntegrityError
from django.http import JsonResponse
from django.contrib.auth.decorators import login_required
from django.core.handlers.wsgi import WSGIRequest
from django.db.models import Q
from authentication import wrappers
from api.models import UserData, Profession, Class
from django.contrib.auth.models import User
from modules import string_operations

# Create your views here.


@login_required
def manage_student(request: WSGIRequest) -> JsonResponse:
    user_data: UserData
    try:
        user_data = UserData.objects.get(for_user=request.user)
    except UserData.DoesNotExist:
        return JsonResponse({'error': 'UserData not found'}, status=404)

    try:
        body: dict = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse({'error': 'Invalid JSON'}, status=400)

    if request.method == "POST" and user_data.role == "admin":
        characters = list(string.ascii_letters + string.digits + string.punctuation)
        new_password = ''
        for i in range(10):
            new_password += random.choice(characters)

        new_username = string_operations.strip_accents(body["name"].replace(" ", "_").lower())

        if body["role"] == "student":
            new_user = User.objects.create_user(
                username=new_username,
                password=new_password,
            )
            new_user_data = UserData.objects.create(
                for_user=new_user,
                role="student",
                name=body["name"],
                student_class=body["student_class"],
                grade=body["grade"],
                mothers_name=body["mothers_name"],
                place_of_birth=body["place_of_birth"],
                date_of_birth=datetime.strptime(body["date_of_birth"], '%Y-%m-%d'),
                address=body["address"],
                profession=Profession.objects.get(name=body["profession"]) if "profession" in body.keys() else None,
                dorm_name=body["dorm_name"] if "dorm_name" in body.keys() else None,
            )
            new_user_data.save()
            new_user.save()

            return JsonResponse({'user_data': {
                "password": new_password,
                "username": new_username
            }}, status=201)
        else:
            return JsonResponse({'error': 'Do not use this endpoint to create regular users'}, status=400)

    else:
        return JsonResponse({'error': 'You do not have enough permissions'}, status=403)


@login_required
@wrappers.require_role(['admin'])
def generate_ids(request: WSGIRequest) -> JsonResponse:
    all_classes = Class.objects.all()

    for i in all_classes:
        for number, student in enumerate(UserData.objects.filter(
                enrollment_date__lt=datetime.fromisoformat(f'{datetime.year}-09-01'),
                enrollment_date__gt=datetime.fromisoformat(f'{datetime.year}-06-15'),
                student_class=i).order_by("name")):
            student.student_number = number + 1
            student.student_id = f'{number + 1}/{student.enrollment_date.year}'
            student.save()
            continue_at = number + 2
        last_number = UserData.objects.filter(student_class=i).order_by("name")[-1].student_number
        continue_at = last_number + 1 if last_number else len(UserData.objects.filter(student_class=i)) + 1
        for student in UserData.objects.filter(
            student_number=None,
            student_id=None,
        ):
            student.student_id = f'{continue_at}/{student.enrollment_date.year}'
            student.student_number = continue_at
            continue_at += 1

    return JsonResponse({"status": "Ok"}, status=200)
