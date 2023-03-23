const {
    getAllBookings,
    getBookingById,
    deleteBooking,
    addBooking,
    getParticularBookings,
} = require('./bookingController')
const { validBooking } = require('./models/bookingModels')

describe('Axios requests suite', () => {
    test('should get a single booking', async () => {
        const response = await getAllBookings()
        expect(response).not.toBeNull()
    })

    test('should get undefined', async () => {
        const response = await getBookingById()
        expect(response).toBeUndefined()
    })

    test('should post a new booking', async () => {
        const response = await addBooking()
        expect(response.bookingFrom).toBe(validBooking.bookingFrom)
    })

    test('should delete an existing booking', async () => {
        const response = await deleteBooking()
        expect(response).toBeUndefined()
    })
})
