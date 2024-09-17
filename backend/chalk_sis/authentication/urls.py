from django.urls import path, include
from authentication import response

urlpatterns = [
    path('login', response.login, name='login'),
    path('logout', response.logout, name='logout'),
    path('no_login', response.no_login, name='no_login'),
]
