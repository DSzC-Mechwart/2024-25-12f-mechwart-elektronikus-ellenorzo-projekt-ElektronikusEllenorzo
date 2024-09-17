from django.db import IntegrityError
from django.http import JsonResponse
from django.contrib.auth.decorators import login_required
from django.contrib.auth import authenticate, login as auth_login, logout as auth_logout
from django.contrib.auth.models import User
from django.core.handlers.wsgi import WSGIRequest
from authentication import wrappers
from api.models import USER_ROLES, UserData
import json, string, random
from modules import string_operations

# Create your views here.


def login(request: WSGIRequest) -> JsonResponse:
    request.session.clear_expired()
    user = authenticate(request, username=request.POST.get("username"), password=request.POST.get("password"))
    if user is not None:
        auth_login(request, user)
        return JsonResponse({"status": "Ok"}, status=200)

    return JsonResponse({"status": "Invalid username or password"}, status=401)


def logout(request: WSGIRequest) -> JsonResponse:
    request.session.clear_expired()
    auth_logout(request)
    return JsonResponse({"status": "Ok"}, status=200)


@login_required
@wrappers.require_role(["admin"])
def add_user(request: WSGIRequest) -> JsonResponse:
    try:
        body: dict = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse({"status": "Invalid JSON"}, status=400)

    if body["role"] == "student":
        return JsonResponse({"error": "Do not use this endpoint to create students"}, status=400)

    characters = list(string.ascii_letters + string.digits + string.punctuation)
    new_password = ''
    for i in range(10):
        new_password += random.choice(characters)

    new_username = string_operations.strip_accents(body["name"].replace(" ", "_").lower())

    new_user = User.objects.create_user(
        username=new_username,
        password=new_password,
    )

    new_user_data = UserData.objects.create(
        for_user=new_user,
        name=body["name"],
        role=body["role"],
    )
    new_user.save()
    new_user_data.save()


@login_required
@wrappers.require_role(["admin"])
def get_available_roles(request: WSGIRequest) -> JsonResponse:
    ...


def no_login(request: WSGIRequest) -> JsonResponse:
    return JsonResponse({"status": "Unauthorized"}, status=401)