from django.urls import path, include
from student import response

urlpatterns = [
    path('manage_student', response.manage_student, name='manage_student'),
    path('generate_ids', response.generate_ids, name='generate_ids'),
    path('all', response.all_student, name='all_student'),
    path('stat', response.statistics, name='statistics'),
    path('<int:student_id>/add_subject/<int:subject_id>', response.add_subject, name='add_subject'),
]
