from django.urls import path

from users.views import UserListAPIView, RetrieveUpdateUserAPIView, UserDestroyAPIView, UserRetrieveAPIView, UserCreateAPIView, UsernameRetrieveAPIView

app_name = 'users'

urlpatterns = [
    path('users/', UserListAPIView.as_view(), name='users_list'),
    path('users/create/', UserCreateAPIView.as_view(), name='users_create'),
    path('users/username/<str:username>/', UsernameRetrieveAPIView.as_view(), name='users_getbyusername'),
    path('users/<int:pk>/', UserRetrieveAPIView.as_view(), name='users_getbyid'),
    path('users/<int:pk>/update/', RetrieveUpdateUserAPIView.as_view(), name='users_update'),
    path('users/<int:pk>/delete/', UserDestroyAPIView.as_view(), name='users_delete'),
]
