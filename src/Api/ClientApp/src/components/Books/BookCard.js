import React from 'react';
import { Card, Badge } from 'react-bootstrap';

const BookCard = ({ posting }) => {

    return (        
        <div style={{height: '100%'}} className='text-center d-flex flex-column justify-content-between'>
            <div>
                <Card.Img variant="top" 
                    src={posting.thumbnail} 
                    className='px-3 pt-3 book-card-img'
                    style={{borderRadius: '10%'}}
                />
            </div>
            <Card.Body className='text-center'>
                <Card.Title>{posting.title}</Card.Title>
                <Card.Text>
                    {posting.author}
                </Card.Text>                    
            </Card.Body>
            <Badge bg='dark' style={{width: '100%'}} className='mb-3 align-middle'>
                <h6>{posting.price} RON</h6>
            </Badge>
        </div>
    )
}

export default BookCard;
