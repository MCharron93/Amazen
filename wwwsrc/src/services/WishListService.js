import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class WishListService {
  async getMyWishLists() {
    try {
      const res = await api.get('api/wish')
      AppState.wishLists = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async getWishListById(wishId) {
    try {
      const res = await api.get('api/wish/' + wishId)
      AppState.singleWishList = res.data
    } catch (error) {
      logger.log(error)
    }
  }
}

export const wishListService = new WishListService()
