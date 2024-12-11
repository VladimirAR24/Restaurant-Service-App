from rest_framework.exceptions import NotFound
from django.contrib.auth import get_user_model
from django.contrib.auth.models import User
from .models import User
from users.serializers import UserSerializer
from rest_framework.generics import ListAPIView, RetrieveAPIView, DestroyAPIView, RetrieveUpdateAPIView, CreateAPIView

from rest_framework import permissions

class UserCreateAPIView(CreateAPIView):
    queryset = User.objects.all()
    model = User
    serializer_class = UserSerializer

    permission_classes = [
        permissions.AllowAny
    ]

class UserListAPIView(ListAPIView):
    queryset = User.objects.all()
    model = User
    serializer_class = UserSerializer

    filterset_fields = ['id', 'username', 'is_active']
    search_fields = ['username', 'email', 'first_name', 'last_name']

    permission_classes = [
        permissions.AllowAny
    ]

class UsernameRetrieveAPIView(RetrieveAPIView):
    model = User
    serializer_class = UserSerializer
    permission_classes = [permissions.AllowAny]

    def get_object(self):
        User = get_user_model()
        username = self.kwargs.get('username')

        try:
            return User.objects.get(username=username)
        except User.DoesNotExist:
            raise NotFound("User not found")

class UserRetrieveAPIView(RetrieveAPIView):
    queryset = User.objects.all()
    model = User
    serializer_class = UserSerializer

    permission_classes = [
        permissions.AllowAny
    ]

class RetrieveUpdateUserAPIView(RetrieveUpdateAPIView):
    queryset = User.objects.all()
    model = User
    serializer_class = UserSerializer

    permission_classes = [
    permissions.AllowAny
    ]

class UserDestroyAPIView(DestroyAPIView):
    queryset = User.objects.all()
    model = User
    serializer_class = UserSerializer

    permission_classes = [
        permissions.AllowAny
    ]
