from django.urls import path, include
from student import response

urlpatterns = [
    path('manage_student', response.manage_student, name='manage_student'),
]
