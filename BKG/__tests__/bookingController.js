const axios = require('axios')

const BASE_URL = 'https://localhost:10001/api/Bookings/'

const getAllBookings = async () => {
    const getResponse = await axios
        .get(BASE_URL)
        .then((response) => response)
        .catch((error) => console.log(error))
    return getResponse
}

const getBookingById = async () => {
    const getResponse = await axios
        .get(BASE_URL + '819F9DE9-10D3-4459-A950-1561A34F0B9D')
        .then((response) => response)
        .catch((error) => console.log(error))
    return getResponse
}

const getParticularBookings = async () => {
    const postResponse = await axios
        .post(BASE_URL + 'get-particular-bookings', {
            bookingFrom: '2023-04-01',
            bookingTo: '2024-05-01',
            hotelId: 'D990989F-BD61-450D-A6E9-B8EED2FD5BA2',
        })
        .then((response) => response)
        .catch((error) => console.log(error))
    return postResponse
}

const addBooking = async () => {
    const postResponse = await axios
        .post(BASE_URL + 'add', {
            bookingFrom: '2023-08-01',
            bookingTo: '2025-01-01',
            price: 10,
            description: 'nodejs',
            hotelId: 'D990989F-BD61-450D-A6E9-B8EED2FD5BA2',
        })
        .then((response) => response)
        .catch((error) => console.log(error))
    return postResponse
}

const deleteBooking = async () => {
    const deleteResponse = await axios
        .delete(BASE_URL + 'delete/819F9DE9-10D3-4459-A950-1561A34F0B9D', {
            id: '819F9DE9-10D3-4459-A950-1561A34F0B9D',
        })
        .then((response) => response)
        .catch((error) => console.log(error))
    return deleteResponse
}

module.exports = {
    getAllBookings,
    getBookingById,
    getParticularBookings,
    addBooking,
    deleteBooking,
}
