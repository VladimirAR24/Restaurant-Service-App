from django.db import models

class orders(models.Model):
    order_details = models.TextField()
    cost = models.DecimalField(max_digits=10, decimal_places=2)
    table_number = models.IntegerField()