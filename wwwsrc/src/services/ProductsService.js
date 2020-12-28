import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class ProductsService {
  async getAvailableProducts() {
    try {
      const res = await api.get('api/products')
      AppState.availableProducts = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async createProduct(newProduct) {
    try {
      const res = await api.post('api/products', newProduct)
      logger.log(res.data)
      this.getAvailableProducts()
    } catch (error) {
      logger.log(error)
    }
  }

  async getSingleProduct(productId) {
    try {
      const res = await api.get('api/products/' + productId)
      AppState.singleProduct = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async editProduct(productId, editData) {
    try {
      await api.put('api/products/' + productId, editData)
    } catch (error) {
      logger.log(error)
    }
  }

  async delete(productId) {
    try {
      const res = await api.delete('api/products/' + productId)
      logger.log(res.data)
    } catch (error) {
      logger.log(error)
    }
  }

  async toggleAvailability(productId) {
    try {
      await api.put('api/products/' + productId + '/availability')
    } catch (error) {
      logger.log(error)
    }
  }
}

export const productsService = new ProductsService()
