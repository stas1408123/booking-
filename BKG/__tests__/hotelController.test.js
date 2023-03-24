const axios = require('axios')
const {
    getHotelById,
    getAllHotels,
    addHotel,
    deleteHotel,
    updateHotel,
    BASE_URL,
    HOTEL_ID,
} = require('./hotelController.js')
const {
    listOfHotels,
    validHotelId,
    invalidHotelId,
    validHotel,
    invalidHotel,
} = require('./models/hotelModels.js')
const ERROR = 'Internal Server Error'

jest.mock('axios')

describe('get hotels', () => {
    describe('when API call is successful', () => {
        test('should return hotel list ', async () => {
            axios.get.mockResolvedValueOnce(listOfHotels)

            const result = await getAllHotels()

            expect(axios.get).toHaveBeenCalledWith(`${BASE_URL}/api/Hotel`)
            expect(result).toEqual(listOfHotels)
        })
    })

    describe('when API call fails', () => {
        test('should return empty hotel list', async () => {
            axios.get.mockRejectedValueOnce(new Error(ERROR))

            const result = await getAllHotels()

            expect(axios.get).toHaveBeenCalledWith(`${BASE_URL}/api/Hotel`)
            expect(result).toEqual([])
        })
    })
})

describe('get hotel by id', () => {
    describe('when API call is successful', () => {
        test('should return hotel model', async () => {
            axios.get.mockResolvedValueOnce(validHotelId)

            const result = await getHotelById()

            expect(axios.get).toHaveBeenCalledWith(
                `${BASE_URL}/api/Hotel/${HOTEL_ID}`
            )
            expect(result).toEqual(validHotelId)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.get.mockRejectedValueOnce(invalidHotelId)

            const result = await getHotelById()

            expect(axios.get).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Hotel/${invalidHotelId}`
            )
            expect(result).toBeNull()
        })
    })
})

describe('add hotel', () => {
    describe('when API call is successfal', () => {
        test('should return new hotel model', async () => {
            axios.post.mockResolvedValueOnce(validHotel)

            const result = await addHotel()

            expect(axios.post).toHaveBeenCalledWith(
                `${BASE_URL}/api/Hotel/add`,
                validHotel
            )
            expect(result).toEqual(validHotel)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.post.mockRejectedValueOnce(invalidHotel)

            const result = await addHotel()

            expect(axios.post).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Hotel/add`,
                invalidHotel
            )
            expect(result).toBeNull()
        })
    })
})

describe('update hotel', () => {
    describe('when API call is successful', () => {
        test('should return updated model', async () => {
            axios.put.mockResolvedValueOnce(validHotel)

            const result = await updateHotel()

            expect(axios.put).toHaveBeenCalledWith(
                `${BASE_URL}/api/Hotel/update`,
                validHotel
            )
            expect(result).toEqual(validHotel)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.put.mockRejectedValueOnce(invalidHotel)

            const result = await updateHotel()

            expect(axios.put).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Hotel/update`,
                invalidHotel
            )
            expect(result).toBeNull()
        })
    })
})

describe('delete booking by id', () => {
    describe('when API call is successful', () => {
        test('should return deleted booking id', async () => {
            axios.delete.mockResolvedValueOnce(validHotelId)

            const result = await deleteHotel()

            expect(axios.delete).toHaveBeenCalledWith(
                `${BASE_URL}/api/Hotel/delete/${HOTEL_ID}`
            )
            expect(result).toEqual(validHotelId)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.delete.mockRejectedValueOnce(invalidHotelId)

            const result = await deleteHotel()

            expect(axios.delete).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Hotel/delete/${invalidHotelId}`
            )
            expect(result).toBeNull()
        })
    })
})
