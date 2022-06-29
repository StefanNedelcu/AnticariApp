import React, { useEffect, useState } from 'react';
import NavMenu from '../NavMenu/NavMenu';
import Profile from '../Profile/Profile';
import ProfileMenu from '../Profile/ProfileMenu';
import { Container, Row, Col, Badge, Form, Button } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faCheck } from '@fortawesome/free-solid-svg-icons';

const Wishlist = () => {
    const [currentUser, setCurrentUser] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const crtUser = JSON.parse(localStorage.getItem('currentUser'));

        setCurrentUser(crtUser);
        setLoading(false);
    }, [])

    return (
        <>
        <NavMenu />
        {currentUser &&
        <Row className='height-95'>
            <Col xs={9} >
                <Container className='mt-5' style={{fontSize: '1.75em'}}>
                    <h1 className='text-center mb-5'>Gestionați lista de dorințe</h1>
                    <Row className='mt-3'>
                        <Badge bg='success' className='px-4 border-5 d-flex justify-content-between'>
                            <span>„Tată bogat, tată sărac” - Robert Kyiosaki</span>
                            <span>
                                <FontAwesomeIcon icon={faTrash} className='text-danger'/>
                            </span>
                        </Badge>
                    </Row>
                    <Row className='mt-3'>
                        <Badge bg='success' className='px-4 border-5 d-flex justify-content-between'>
                            <span>„Enigma Otiliei” - George Călinescu</span>
                            <span>
                                <FontAwesomeIcon icon={faTrash} className='text-danger'/>
                            </span>
                        </Badge>
                    </Row>
                    <Row className='mt-3'>
                        <Badge bg='secondary' className='px-4 border-5 d-flex justify-content-between'>
                            <span>„Arta războiului” - Sun Tzu</span>
                            <span>
                                <FontAwesomeIcon icon={faCheck} className='text-warning mx-2'/>
                                <FontAwesomeIcon icon={faTrash} className='text-danger'/>
                            </span>
                        </Badge>
                    </Row>                    
                    <Row className='mt-4'>
                        <Col xs={12} md={5}>
                            <Form.Group className="mb-3" >
                                <Form.Control type="text" placeholder="Titlu" />
                            </Form.Group>
                        </Col>
                        <Col xs={12} md={5}>
                            <Form.Group className="mb-3" >
                                <Form.Control type="text" placeholder="Autor" />
                            </Form.Group>
                        </Col>
                        <Col xs={12} md={2}>
                            <Button variant='primary' disabled={loading}>Adăugați</Button>
                        </Col>
                    </Row>
                </Container>
            </Col>
            <Col xs={3} className='side-panel'>
                <Profile userId={currentUser.userId} />
                <ProfileMenu />
            </Col>
        </Row>}
        </>
    )
}

export default Wishlist;