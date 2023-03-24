const listOfHotels = [
    {
        id: '5dsad636304',
        title: 'ds EBANAYA',
        describtion: 'POZOR',
        createdTime: '2023-01-01',
        owner: 'PIDOR',
        stars: 3,
        countRooms: 123,
        phoneNumber: '+3432424234',
    },
    {
        id: '5d17f294-fcbedsadsa40173636304',
        title: 'HUETA s',
        describtion: 'POZOR',
        createdTime: '2021-01-01',
        owner: 'PIDOR',
        stars: 3,
        countRooms: 123,
        phoneNumber: '+3432424234',
    },
    {
        id: '5d17f294-fcbdasdasdasaa173636304',
        title: 'a EBANAYA',
        describtion: 'POZOR',
        createdTime: '2020-01-01',
        owner: 's',
        stars: 3,
        countRooms: 123,
        phoneNumber: '+3432424234',
    },
]

const validHotelId = '5d17f294-fcbe-432b-b297-c40173636304'

const invalidHotelId = 'asdsadasdsadsadasd'

const validHotel = {
    id: '5d17f294-fcbe-432b-b297-c40173636304',
    title: 'HUETA EBANAYA',
    describtion: 'POZOR',
    createdTime: '2020-01-01',
    owner: 'PIDOR',
    stars: 3,
    countRooms: 123,
    phoneNumber: '+3432424234',
}

const invalidHotel = {
    title: 'DON YAGON',
}

module.exports = {
    listOfHotels,
    validHotelId,
    invalidHotelId,
    validHotel,
    invalidHotel,
}
