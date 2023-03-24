const listOfBooking = [
    {
        bookingFrom: '2023-08-01',
        bookingTo: '2025-01-01',
        price: 10,
        description: 'nodejs',
        hotelId: 'd990989f-bd61-450d-a6e9-b8eed2fd5ba2',
    },
    {
        bookingFrom: '2023-08-02',
        bookingTo: '2025-01-02',
        price: 30,
        description: 'nodejs',
        hotelId: 'd990989f-bd61-450d-a6e9-b8eed2fd5ba2',
    },
    {
        bookingFrom: '2023-08-03',
        bookingTo: '2025-01-03',
        price: 130,
        description: 'nodejs',
        hotelId: 'd990989f-bd61-450d-a6e9-b8eed2fd5ba2',
    },
]

const validParticularBookingsSearch = {
    bookingFrom: '2020-01-01',
    bookingTo: '2025-01-01',
    hotelId: 'd990989f-bd61-450d-a6e9-b8eed2fd5ba2',
}

const invalidParticularBookingsSearch = {
    bookingFrom: '2020-01-01',
    bookingTo: '2025-01-01',
}

const listOfParticularBookings = [
    {
        bookingFrom: '2023-08-01',
        bookingTo: '2025-01-01',
        price: 10,
        description: 'nodejs',
        hotelId: 'd990989f-bd61-450d-a6e9-b8eed2fd5ba2',
    },
    {
        bookingFrom: '2023-08-02',
        bookingTo: '2025-01-02',
        price: 30,
        description: 'nodejs',
        hotelId: 'd990989f-bd61-450d-a6e9-b8eed2fd5ba2',
    },
    {
        bookingFrom: '2023-08-03',
        bookingTo: '2025-01-03',
        price: 130,
        description: 'nodejs',
        hotelId: 'd990989f-bd61-450d-a6e9-b8eed2fd5ba2',
    },
]

const validBooking = {
    id: '5d17f294-fcbe-432b-b297-c40173636304',
    bookingFrom: '2020-01-01',
    bookingTo: '2025-01-01',
    hotelId: '44313438-be7f-46a1-a7f7-40621e0fc36d',
    price: 10,
    describtion: 'hueta ebanaya',
}

const invalidBooking = {
    id: 'HUETA-HUETA',
}

const validBookingId = '5aaf692a-8a48-4657-bf8c-f12fe207ed27'

const invalidBookingId = '3eaa1d9d-be86-46bb-8aa3-806de687d479'

module.exports = {
    validBooking,
    listOfBooking,
    validBookingId,
    invalidBookingId,
    validBooking,
    invalidBooking,
    validParticularBookingsSearch,
    invalidParticularBookingsSearch,
    listOfParticularBookings,
}
