import React, { useEffect, useState } from 'react';
import axiosInstance from "../../config/Axios";
import { Button } from "react-bootstrap";
import Image from 'react-bootstrap/Image';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faStar } from '@fortawesome/free-solid-svg-icons'

const BookWidget = (props) => {
    return (
        <div className='text-center'>
            <h1 className='mt-5'>Profil</h1>
            <Image
                src='witcher.jpg'
                className='my-3 book-widget-img'
            />
            <h3>The Witcher</h3>
            <Button variant="light" style={{width: '100px'}} className='mb-4'><strong>30 lei</strong></Button>
            <div><strong>Autor:</strong> <em>Andrzej Sapkowski</em></div>
            <div><strong>Editura:</strong> <em>Nemira</em></div>
            <div><strong>Postat de:</strong> <em>Stefan Nedelcu</em> <span>(5 <FontAwesomeIcon icon={faStar} className='text-warning'/>)</span></div>
            <div><strong>Data:</strong> <em>25.06.2022</em></div>
            <div><strong>Adresa:</strong> <em>Bucuresti, Mihai Bravu 139</em></div>
            <div><strong>Descriere:</strong> <em>The Witcher is a series of six fantasy novels and 15 short stories written by Polish author Andrzej Sapkowski. The series revolves around the eponymous "witcher," Geralt of Rivia. In Sapkowski's works, "witchers" are beast hunters who develop supernatural abilities at a young age to battle wild beasts and monsters.</em></div>
            <Button variant='primary' style={{width: '100%'}} className='mt-2'>Cumpărat</Button>
        </div>
    )
}

export default BookWidget;
