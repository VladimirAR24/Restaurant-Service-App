from rest_framework import serializers
from users.models import User

class UserSerializer(serializers.ModelSerializer):
    class Meta:
        model = User
        fields = ('id', 'username', 'email', 'password', 'first_name', 'last_name')
    
    extra_kwargs = {
            'password': {'write_only': True}
        }
    
    def create(self, validated_data):
        # Создаем пользователя
        user = User(**validated_data)
        user.set_password(validated_data['password'])
        user.save()
        return user