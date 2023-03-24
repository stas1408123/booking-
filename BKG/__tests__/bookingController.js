const axios = require('axios')

const BASE_URL = 'https://localhost:10001'
const BOOKING_ID = '5aaf692a-8a48-4657-bf8c-f12fe207ed27'

const getAllBookings = async () => {
    try {
        return await axios.get(`${BASE_URL}/api/Booking`)
    } catch (error) {
        return []
    }
}

const getBookingById = async () => {
    try {
        return await axios.get(`${BASE_URL}/api/Booking/${BOOKING_ID}`)
    } catch (error) {
        return null
    }
}

const addBooking = async () => {
    try {
        return await axios.post(`${BASE_URL}/api/Booking/add`, {
            id: '5d17f294-fcbe-432b-b297-c40173636304',
            bookingFrom: '2020-01-01',
            bookingTo: '2025-01-01',
            hotelId: '44313438-be7f-46a1-a7f7-40621e0fc36d',
            price: 10,
            describtion: 'hueta ebanaya',
        })
    } catch (error) {
        return null
    }
}

const updateBooking = async () => {
    try {
        return await axios.put(`${BASE_URL}/api/Booking/update`, {
            id: '5d17f294-fcbe-432b-b297-c40173636304',
            bookingFrom: '2020-01-01',
            bookingTo: '2025-01-01',
            hotelId: '44313438-be7f-46a1-a7f7-40621e0fc36d',
            price: 10,
            describtion: 'hueta ebanaya',
        })
    } catch (error) {
        return null
    }
}

const deleteBooking = async () => {
    try {
        return await axios.delete(
            `${BASE_URL}/api/Booking/delete/${BOOKING_ID}`
        )
    } catch (error) {
        return null
    }
}

const getParticularBookings = async () => {
    try {
        return await axios.post(
            `${BASE_URL}/api/Booking/get-particular-bookings`,
            {
                bookingFrom: '2020-01-01',
                bookingTo: '2025-01-01',
                hotelId: 'd990989f-bd61-450d-a6e9-b8eed2fd5ba2',
            }
        )
    } catch (error) {
        return []
    }
}

module.exports = {
    getAllBookings,
    getBookingById,
    addBooking,
    updateBooking,
    deleteBooking,
    getParticularBookings,
    BASE_URL,
    BOOKING_ID,
}
