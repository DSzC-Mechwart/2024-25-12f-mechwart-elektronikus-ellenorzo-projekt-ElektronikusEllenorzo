from django.urls import path, include
import authentication.urls
import student.urls

urlpatterns = [
    path('auth/', include(authentication.urls)),
    path('student/', include(student.urls)),
]
