const axios = require('axios')
const {
    getAllBookings,
    getBookingById,
    BASE_URL,
    BOOKING_ID,
    addBooking,
    updateBooking,
    deleteBooking,
    getParticularBookings,
} = require('./bookingController.js')
const {
    validBookingId,
    listOfBooking,
    invalidBookingId,
    validBooking,
    invalidBooking,
    validParticularBookingsSearch,
    invalidParticularBookingsSearch,
    listOfParticularBookings,
} = require('./models/bookingModels.js')
const ERROR = 'Internal Server Error'

jest.mock('axios')

describe('get bookings', () => {
    describe('when API call is successful', () => {
        test('should return booking list ', async () => {
            axios.get.mockResolvedValueOnce(listOfBooking)

            const result = await getAllBookings()

            expect(axios.get).toHaveBeenCalledWith(`${BASE_URL}/api/Booking`)
            expect(result).toEqual(listOfBooking)
        })
    })

    describe('when API call fails', () => {
        test('should return empty booking list', async () => {
            axios.get.mockRejectedValueOnce(new Error(ERROR))

            const result = await getAllBookings()

            expect(axios.get).toHaveBeenCalledWith(`${BASE_URL}/api/Booking`)
            expect(result).toEqual([])
        })
    })
})

describe('get booking by id', () => {
    describe('when API call is successful', () => {
        test('should return booking model', async () => {
            axios.get.mockResolvedValueOnce(validBookingId)

            const result = await getBookingById()

            expect(axios.get).toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/${BOOKING_ID}`
            )
            expect(result).toEqual(validBookingId)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.get.mockRejectedValueOnce(invalidBookingId)

            const result = await getBookingById()

            expect(axios.get).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/${invalidBooking}`
            )
            expect(result).toBeNull()
        })
    })
})

describe('add booking', () => {
    describe('when API call is successfal', () => {
        test('should return new booking model', async () => {
            axios.post.mockResolvedValueOnce(validBooking)

            const result = await addBooking()

            expect(axios.post).toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/add`,
                validBooking
            )
            expect(result).toEqual(validBooking)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.post.mockRejectedValueOnce(invalidBooking)

            const result = await addBooking()

            expect(axios.post).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/add`,
                invalidBooking
            )
            expect(result).toBeNull()
        })
    })
})

describe('update booking', () => {
    describe('when API call is successful', () => {
        test('should return updated model', async () => {
            axios.put.mockResolvedValueOnce(validBooking)

            const result = await updateBooking()

            expect(axios.put).toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/update`,
                validBooking
            )
            expect(result).toEqual(validBooking)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.put.mockRejectedValueOnce(invalidBooking)

            const result = await updateBooking()

            expect(axios.put).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/update`,
                invalidBooking
            )
            expect(result).toBeNull()
        })
    })
})

describe('delete booking by id', () => {
    describe('when API call is successful', () => {
        test('should return deleted booking id', async () => {
            axios.delete.mockResolvedValueOnce(validBookingId)

            const result = await deleteBooking()

            expect(axios.delete).toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/delete/${BOOKING_ID}`
            )
            expect(result).toEqual(validBookingId)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.delete.mockRejectedValueOnce(invalidBookingId)

            const result = await deleteBooking()

            expect(axios.delete).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/delete/${invalidBooking}`
            )
            expect(result).toBeNull()
        })
    })
})

describe('get particular bookings', () => {
    describe('when API call is successful', () => {
        test('should return particular bookings', async () => {
            axios.post.mockResolvedValueOnce(listOfParticularBookings)

            const result = await getParticularBookings()

            expect(axios.post).toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/get-particular-bookings`,
                validParticularBookingsSearch
            )
            expect(result).toEqual(listOfParticularBookings)
        })
    })

    describe('when API call fails', () => {
        test('should return null', async () => {
            axios.post.mockRejectedValueOnce(listOfParticularBookings)

            const result = await getParticularBookings()

            expect(axios.post).not.toHaveBeenCalledWith(
                `${BASE_URL}/api/Booking/get-particular-bookings`,
                invalidParticularBookingsSearch
            )
            expect(result).toEqual([])
        })
    })
})
