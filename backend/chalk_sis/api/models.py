from django.db import models
from django.contrib.auth.models import User

USER_ROLES = (
    ("admin", "Admin"),
    ("teacher", "Teacher"),
    ("student", "Student"),
)

# Create your models here.


class Profession(models.Model):
    name = models.CharField(max_length=255, unique=True)

    def __str__(self):
        return self.name


class Subject(models.Model):
    name = models.CharField(max_length=255)
    is_professional = models.BooleanField(default=False)

    def __str__(self):
        return self.name


class UserData(models.Model):
    for_user = models.ForeignKey(User, on_delete=models.CASCADE)
    role = models.CharField(max_length=255, choices=USER_ROLES)
    student_class = models.CharField(max_length=8, null=True, blank=True)
    grade = models.IntegerField(default=None, null=True, blank=True)
    name = models.CharField(max_length=255)
    mothers_name = models.CharField(max_length=255, null=True, blank=True)
    place_of_birth = models.CharField(max_length=255, null=True, blank=True)
    date_of_birth = models.DateField(null=True, blank=True)
    address = models.CharField(max_length=255, null=True, blank=True)
    enrollment_date = models.DateField(null=True, blank=True, auto_now=True)
    profession = models.OneToOneField(Profession, on_delete=models.CASCADE, null=True, blank=True)
    subjects = models.ManyToManyField(Subject, blank=True)
    lives_in_dorm = models.BooleanField(default=False)
    dorm_name = models.CharField(max_length=255, null=True, blank=True)
    is_first_login = models.BooleanField(default=True)

    def __str__(self):
        return f"{self.for_user.username} ({self.role})"


class Grade(models.Model):
    value = models.IntegerField(default=1)
    note = models.CharField(max_length=255, null=True, blank=True)
    date = models.DateField(auto_now=True)
    student = models.OneToOneField(User, on_delete=models.CASCADE)
    subject = models.OneToOneField(Subject, on_delete=models.CASCADE)

    def __str__(self):
        return f"{self.student} - {self.value} ({self.subject})"
