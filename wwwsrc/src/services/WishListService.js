import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class WishListService {
  async getMyWishLists() {
    try {
      const res = await api.get('api/wish')
      logger.log(res.data)
      AppState.wishLists = res.data
    } catch (error) {
      logger.log(error)
    }
  }
}

export const wishListService = new WishListService()
