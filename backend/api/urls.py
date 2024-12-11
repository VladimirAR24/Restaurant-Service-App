from django.urls import path
from . import views

urlpatterns = [
    path('', views.getData),
    path('add/', views.newUser),
    path('delete/<int:id>/', views.deleteUser),
    path('update/<int:id>/', views.updateUser),
    path('getbyid/<int:id>/', views.getById),
    path('getbyusername/<str:username>/', views.getByUsername)
]
