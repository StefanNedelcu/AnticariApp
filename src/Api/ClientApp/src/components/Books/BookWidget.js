import React, { useEffect, useState } from 'react';
import axiosInstance from "../../config/Axios";
import { Button, Modal } from "react-bootstrap";
import Image from 'react-bootstrap/Image';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faStar } from '@fortawesome/free-solid-svg-icons';
import Moment from 'moment';
import StarRatings from 'react-star-ratings';

const BookWidget = ({ posting }) => {
    const [createdAt, setCreatedAt] = useState();
    const [show, setShow] = useState(false);
    const [rating, setRating] = useState(0);

    useEffect(() => {
        const date = new Date(posting.createdAt);
        setCreatedAt(Moment(date).format('DD-MM-YYYY'))
    }, [])

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const handleConfirm = () => {
        axiosInstance.patch(`posting/${posting.postingId}`, { rating })
            .then(() => {
                console.log('success')
            })
            .finally(() => setShow(false));
    }

    return (
        <>
        <div className='text-center'>
            <Image
                src={posting.thumbnail}
                className='my-3 book-widget-img'
                rounded={25}
            />
            <h3>{posting.title}</h3>
            <Button variant="light" style={{width: '100px'}} className='mb-4'><strong>30 lei</strong></Button>
            <div><strong>Autor:</strong> <em>{posting.author}</em></div>
            <div><strong>Categorie:</strong> <em>{posting.category}</em></div>
            <div>
                <strong>Postat de: </strong> 
                <em>{`${posting.owner.firstName} ${posting.owner.lastName}`} </em> 
                <span>
                    ({posting.owner.statistics.avgRating ?
                    <>{posting.owner.statistics.avgRating} <FontAwesomeIcon icon={faStar} className='text-warning'/></> :
                    <>rating: N/A</>})
                </span>
            </div>
            <div><strong>Email: </strong><em>{posting.owner.email}</em></div>
            <div><strong>Telefon: </strong><em>{posting.owner.phoneNumber}</em></div>
            <div><strong>Adresa: </strong><em>{posting.owner.address}</em></div>
            <div><strong>Postat la: </strong><em>{createdAt}</em></div>
            <div><strong>Descriere: </strong><em>{posting.description}</em></div>
            <Button variant='primary' style={{width: '90%'}} className='mt-2'
                onClick={handleShow}
            >
                Cumpărat
            </Button>
        </div>
        
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Confirmați tranzacția</Modal.Title>
            </Modal.Header>
            <Modal.Body className='text-center'>
                Vă rugăm să acordați un rating vânzătorului produsului.
                <StarRatings
                    rating={rating}
                    starRatedColor='yellow'
                    changeRating={setRating}
                    numberOfStars={5}
                    name='rating'
                />
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Închideți
                </Button>
                <Button variant="primary" onClick={handleConfirm}>
                    Confirmați
                </Button>
            </Modal.Footer>
        </Modal>

        </>
    )
}

export default BookWidget;
