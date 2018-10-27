package repositories

import (
	"basket.api/models"
)

type BasketRepository interface {
	GetBasket(customerID string) (*models.CustomerBasket, error)
	Update(item *models.CustomerBasket) error
	Delete(id string) error
}