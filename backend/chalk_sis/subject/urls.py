from django.urls import path, include
from subject import response

urlpatterns = [
    path('manage', response.manage, name='manage'),
    path('manage/<int:subject_id>', response.manage, name='manage'),
]
