from django.contrib import admin

from api.models import Grade, Profession, Subject, UserData, Class

# Register your models here.
admin.site.register(Profession)
admin.site.register(Subject)
admin.site.register(UserData)
admin.site.register(Grade)
admin.site.register(Class)
