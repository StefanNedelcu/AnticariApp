import React, { useEffect, useState } from 'react';
import axiosInstance from "../../config/Axios";
import Image from 'react-bootstrap/Image';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faAward, faTrophy, faStar } from '@fortawesome/free-solid-svg-icons'

const Profile = (props) => {
    const [user, setUser] = useState(null);    

    useEffect(() => {
        getUser(props.userId);
    }, [])

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
            <h1 className='mt-5'>Profil</h1>
            <Image
                src='profile-placeholder.png'
                roundedCircle
                className='my-3'
            />
            <h3>{user.firstName}</h3>
            <h3>{user.lastName}</h3>
            <div><strong>Email: </strong><em>{user.email}</em></div>
            <div><strong>Telefon: </strong><em>{user.phoneNumber}</em></div>
            <div><strong>Adresa: </strong><em>{user.address}</em></div>
            <div><strong>Rating: </strong>
                <em>
                    {user.statistics.avgRating ? 
                    <>{user.statistics.avgRating} <FontAwesomeIcon icon={faStar} className='text-warning'/></> : 
                    "N/A"}
                </em>
            </div>
        </div>
        </>
    )
}

export default Profile;
