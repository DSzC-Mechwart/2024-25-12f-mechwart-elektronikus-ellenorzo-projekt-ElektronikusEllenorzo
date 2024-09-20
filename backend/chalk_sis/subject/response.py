import json
from django.forms import model_to_dict
from django.http import JsonResponse
from django.contrib.auth.decorators import login_required
from django.core.handlers.wsgi import WSGIRequest
from authentication import wrappers
from api.models import Subject


# Create your views here.


@login_required
@wrappers.require_role(["admin"])
def manage(request: WSGIRequest, subject_id=None) -> JsonResponse:
    if request.method == "POST":
        try:
            body = json.loads(request.body.decode('utf-8'))
        except json.JSONDecodeError:
            return JsonResponse({"error": "Invalid JSON"}, status=400)

        count_per_year = (
                36 * body['count_per_week']
        ) if 9 <= body["grade"] <= 11 else (
                36 * body['count_per_week']
        ) if body["grade"] == 12 and body["is_professional"] else (
                31 * body['count_per_week']
        ) if body["grade"] == 12 and not body["is_professional"] else (
                31 * body['count_per_week']
        )

        Subject.objects.create(**body, count_per_year=count_per_year).save()

        return JsonResponse({"status": "Ok"}, status=200)
    elif request.method == "PATCH":
        if subject_id is None:
            return JsonResponse({"error": "Subject ID is required"}, status=400)
        try:
            body = json.loads(request.body.decode('utf-8'))
            subject_object = Subject.objects.get(id=subject_id)
        except Subject.DoesNotExist:
            return JsonResponse({"error": "Subject does not exist"}, status=400)
        except json.JSONDecodeError:
            return JsonResponse({"error": "Invalid JSON"}, status=400)

        if "count_per_week" in body.keys():
            count_per_year = (
                    36 * body['count_per_week']
            ) if 9 <= body["grade"] <= 11 else (
                    36 * body['count_per_week']
            ) if body["grade"] == 12 and body["is_professional"] else (
                    31 * body['count_per_week']
            ) if body["grade"] == 12 and not body["is_professional"] else (
                    31 * body['count_per_week']
            )
            subject_object.update(count_per_year=count_per_year)
        subject_object.update(**body)
        subject_object.save()

        return JsonResponse({"status": "Ok"}, status=200)
    elif request.method == "DELETE":
        try:
            Subject.objects.get(id=subject_id).delete()
        except Subject.DoesNotExist:
            return JsonResponse({"error": "Subject does not exist"}, status=400)
        return JsonResponse({"status": "Ok"}, status=200)

