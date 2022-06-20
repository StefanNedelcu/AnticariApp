import React, { useEffect, useState } from 'react';
import axiosInstance from "../../config/Axios";
import { useHistory } from "react-router-dom";
import Image from 'react-bootstrap/Image';
import { Button } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faAward, faTrophy } from '@fortawesome/free-solid-svg-icons'

const Profile = (props) => {
    const history = useHistory();
    const [user, setUser] = useState(null);    

    useEffect(() => {
        getUser(props.userId);
    }, [])

    async function logout() {
        await axiosInstance.get('auth')
            .then(() => { 
                localStorage.setItem('currentUser', null);
            })
            .finally(() => history.push('/login'));
    }

    async function getUser(userId) {
        await axiosInstance.get(`user/${userId}`)
            .then(({ data }) => {
                setUser(data);
            })
    }

    return (
        user &&
        <>
        <div className='mt-2 mx-4 d-flex flex-row justify-content-between'>
            {user.statistics.soldItems >= 5 &&
            <FontAwesomeIcon icon={faAward} className='profile-badge text-primary' />}
            {user.statistics.readBooks >= 5 && 
            <FontAwesomeIcon icon={faTrophy} className='profile-badge text-warning' />}
        </div>
        <div className='text-center'>
            <h1 className='mt-5'>Meniu</h1>
            <Image
                src='profile-placeholder.png'
                roundedCircle
                className='my-3'
            />
            <h3>{user.firstName}</h3>
            <h3>{user.lastName}</h3>
            <div><strong>Email:</strong> {user.email}</div>
            <div><strong>Telefon:</strong> {user.phoneNumber}</div>
            <div><strong>Adresa:</strong> {user.address}</div>
            <div><strong>Rating mediu:</strong> {user.statistics.avgRating ? user.statistics.avgRating : "N/A"} </div>
            <div className='mt-4'>
                <Button variant="light" size='sm' className='mx-2'>
                    Editați
                </Button>

                <Button variant="light" size='sm' onClick={logout}>
                    Logout
                </Button>
            </div>
        </div>
        </>
    )
}

export default Profile;
