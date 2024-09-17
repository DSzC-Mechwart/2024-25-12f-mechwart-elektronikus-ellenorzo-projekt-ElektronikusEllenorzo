from django.db import IntegrityError
from django.http import JsonResponse
from django.contrib.auth.decorators import login_required
from django.contrib.auth import authenticate, login as auth_login, logout as auth_logout
from django.core.handlers.wsgi import WSGIRequest
from authentication import wrappers
from api.models import USER_ROLES
import json

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
    ...


@login_required
@wrappers.require_role(["admin"])
def get_available_roles(request: WSGIRequest) -> JsonResponse:
    ...


def no_login(request: WSGIRequest) -> JsonResponse:
    return JsonResponse({"status": "Unauthorized"}, status=401)
