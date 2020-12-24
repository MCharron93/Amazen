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
      logger.log(editData, productId)
      await api.put('api/products/' + productId, editData)
    } catch (error) {
      logger.log(error)
    }
  }
}

export const productsService = new ProductsService()
