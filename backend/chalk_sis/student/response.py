import json
from datetime import datetime
import string, random
from django.db import IntegrityError
from django.http import JsonResponse
from django.contrib.auth.decorators import login_required
from django.core.handlers.wsgi import WSGIRequest
from authentication import wrappers
from api.models import UserData, Profession
from django.contrib.auth.models import User
from modules import string_operations

# Create your views here.


@login_required
def manage_student(request: WSGIRequest) -> JsonResponse:
    user_data: UserData
    try:
        user_data = UserData.objects.get(for_user=request.user)
    except:
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
                lives_in_dorm=body["lives_in_dorm"],
                dorm_name=body["dorm_name"] if "dorm_name" in body.keys() else None,
            )
            new_user_data.save()
            new_user.save()

            return JsonResponse({'user_data': {
                "password": new_password,
                "username": new_username
            }}, status=201)
    else:
        return JsonResponse({'error': 'You do not have enough permissions'}, status=403)
