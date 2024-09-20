from django.urls import path, include
from student import response

urlpatterns = [
    path('manage_student', response.manage_student, name='manage_student'),
    path('generate_ids', response.generate_ids, name='generate_ids'),
]
