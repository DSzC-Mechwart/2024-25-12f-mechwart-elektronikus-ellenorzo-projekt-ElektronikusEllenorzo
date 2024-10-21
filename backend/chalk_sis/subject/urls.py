from django.urls import path, include
from subject import response

urlpatterns = [
    path('manage', response.manage, name='manage'),
    path('manage/<int:subject_id>', response.manage, name='manage'),
    path('stat', response.subject_statistics, name='subject_statistics'),
    path('all', response.all_subject, name='all_subject'),
    path('all/<int:grade>', response.all_subject, name='all_subject'),
]
