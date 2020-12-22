import { logger } from "../utils/Logger";
import {api } from "./services/AxiosService"

class ProductsService{
  async getAvailableProducts()
  {
    try {
      const res = await api.get('api/products')
      logger.log(res.data)
    } catch (error) {
      logger.log(error)
    }
  }
}

export const productsService = new ProductsService()
