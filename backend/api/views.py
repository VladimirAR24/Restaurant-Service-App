from rest_framework.response import Response
from rest_framework.decorators import api_view
from users.models import User
from api.serializers import UserSerializer

@api_view(['GET'])
def getData(request):
    users = User.objects.all()
    serializer = UserSerializer(users, many=True)
    return Response(serializer.data)

@api_view(['POST'])
def newUser(request):
    serializer = UserSerializer(data=request.data)
    if serializer.is_valid():
        serializer.save()
    return Response(serializer.data)

@api_view(['DELETE'])
def deleteUser(request, id):
    try:
        user = User.objects.get(pk=id)
        user.delete()
        return Response({"Deleted successfully"})
    except User.DoesNotExist:
        return Response({'error': 'User not found'})
    
@api_view(['PATCH'])
def updateUser(request, id):
    try:
        user = User.objects.get(pk=id)
    except User.DoesNotExist:
        return Response({'error': 'User not found'})

    serializer = UserSerializer(user, data=request.data, partial=True)
    if serializer.is_valid():
        serializer.save()
        return Response(serializer.data)
    
    return Response(serializer.errors)

@api_view(['GET'])
def getById(request, id):
    try:
        user = User.objects.get(pk=id)
        serializer = UserSerializer(user)
        return Response(serializer.data)
    except User.DoesNotExist:
        return Response({'error': 'User not found'})
    
@api_view(['GET'])
def getByUsername(request, username):
    try:
        username = User.objects.get(username=username)
        serializer = UserSerializer(username)
        return Response(serializer.data)
    except User.DoesNotExist:
        return Response({'error': 'User not found'})