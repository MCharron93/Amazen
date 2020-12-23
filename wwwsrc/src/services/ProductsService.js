import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class ProductsService {
  async getAvailableProducts() {
    try {
      const res = await api.get('api/products')
      AppState.availableProducts = res.data
      logger.log(AppState.availableProducts)
    } catch (error) {
      logger.log(error)
    }
  }

  async getSingleProduct(productId) {
    try {
      const res = await api.get('api/products/' + productId)
      logger.log(res.data)
    } catch (error) {
      logger.log(error)
    }
  }
}

export const productsService = new ProductsService()
