from django.urls import path, include
from authentication import response

urlpatterns = [
    path('login', response.login, name='login'),
    path('change_password', response.change_password, name='change_password'),
    path('logout', response.logout, name='logout'),
    path('add_user', response.add_user, name='add_user'),
    path('no_login', response.no_login, name='no_login'),
]
