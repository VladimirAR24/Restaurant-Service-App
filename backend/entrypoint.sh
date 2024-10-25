#!/bin/sh

python manage.py migrate

if [ "$DEBUG" = "False" ]
then
    python manage.py collectstatic --noinput
fi

if [ "$DJANGO_SUPERUSER_USERNAME" ]
then
    python manage.py createsuperuser \
        --noinput \
        --username $DJANGO_SUPERUSER_USERNAME \
        --email $DJANGO_SUPERUSER_EMAIL
fi

gunicorn config.wsgi:application --bind 0.0.0.0:8000 --workers=4

exec "$@"