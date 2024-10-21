import json

from django.core.serializers import serialize
from django.db.models import Count, F, When, Sum, Case
from django.forms import model_to_dict, IntegerField
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

    return JsonResponse({"error": "Method not allowed"}, status=405)


@login_required
@wrappers.require_role(["admin"])
def subject_statistics(request: WSGIRequest) -> JsonResponse:
    subject_stats = {}

    professional_subjects = Subject.objects.filter(is_professional=True)
    subject_stats["professional_subjects"] = professional_subjects.count()

    standard_subjects = Subject.objects.filter(is_professional=False)
    subject_stats["standard_subjects"] = standard_subjects.count()

    subject_summary = Subject.objects.values('grade').annotate(
        professional_count=Count(Case(When(is_professional=True, then=1))),
        non_professional_count=Count(Case(When(is_professional=False, then=1))),
        total_count=Count('id'),
        professional_hours=Sum(Case(When(is_professional=True, then='count_per_year'))),
        non_professional_hours=Sum(
            Case(When(is_professional=False, then='count_per_year'))),
        total_hours=Sum('count_per_year')
    ).order_by('grade')

    return JsonResponse({
        "total_professional": professional_subjects.count(),
        "total_standard": standard_subjects.count(),
        "per_grade": [i for i in subject_summary],
    })


@login_required
@wrappers.require_role(["admin"])
def all_subject(request: WSGIRequest, grade=None) -> JsonResponse:
    if grade is None:
        return JsonResponse({"subjects": [model_to_dict(i) for i in Subject.objects.all()]}, status=200)
    return JsonResponse({"subjects": [model_to_dict(i) for i in Subject.objects.filter(grade=grade)]}, status=200)


