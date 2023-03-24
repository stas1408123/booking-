const axios = require('axios')

const BASE_URL = 'https://localhost:10001'
const HOTEL_ID = '5aaf692a-8a48-4657-bf8c-f12fe207ed27'

const getAllHotels = async () => {
    try {
        return await axios.get(`${BASE_URL}/api/Hotel`)
    } catch (error) {
        return []
    }
}

const getHotelById = async () => {
    try {
        return await axios.get(`${BASE_URL}/api/Hotel/${HOTEL_ID}`)
    } catch (error) {
        return null
    }
}

const addHotel = async () => {
    try {
        return await axios.post(`${BASE_URL}/api/Hotel/add`, {
            id: '5d17f294-fcbe-432b-b297-c40173636304',
            title: 'HUETA EBANAYA',
            describtion: 'POZOR',
            createdTime: '2020-01-01',
            owner: 'PIDOR',
            stars: 3,
            countRooms: 123,
            phoneNumber: '+3432424234',
        })
    } catch (error) {
        return null
    }
}

const updateHotel = async () => {
    try {
        return await axios.put(`${BASE_URL}/api/Hotel/update`, {
            id: '5d17f294-fcbe-432b-b297-c40173636304',
            title: 'HUETA EBANAYA',
            describtion: 'POZOR',
            createdTime: '2020-01-01',
            owner: 'PIDOR',
            stars: 3,
            countRooms: 123,
            phoneNumber: '+3432424234',
        })
    } catch (error) {
        return null
    }
}

const deleteHotel = async () => {
    try {
        return await axios.delete(`${BASE_URL}/api/Hotel/delete/${HOTEL_ID}`)
    } catch (error) {
        return null
    }
}

module.exports = {
    getAllHotels,
    getHotelById,
    addHotel,
    updateHotel,
    deleteHotel,
    BASE_URL,
    HOTEL_ID,
}
