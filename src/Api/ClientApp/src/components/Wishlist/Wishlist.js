import React, { useEffect, useState } from 'react';
import NavMenu from '../NavMenu/NavMenu';
import Profile from '../Profile/Profile';
import ProfileMenu from '../Profile/ProfileMenu';
import { Container, Row, Col, Badge, Form, Button } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrash, faCheck } from '@fortawesome/free-solid-svg-icons';
import axiosInstance from '../../config/Axios';

const Wishlist = () => {
    const [currentUser, setCurrentUser] = useState(null);
    const [wishlist, setWishlist] = useState([]);
    const [newItem, setNewItem] = useState({
        bookTitle: '',
        authorName: ''
    });
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const crtUser = JSON.parse(localStorage.getItem('currentUser'));

        setCurrentUser(crtUser);
        populateWishlist(crtUser);
        setLoading(false);
    }, [])

    const populateWishlist = (crtUser) => {
        setLoading(true);

        axiosInstance.get(`wishlist/user/${crtUser.userId}`)
            .then(({ data }) => {
                setWishlist(data);
            })
            .finally(() => setLoading(false));
    }

    const deleteItem = (item) => {
        if (loading) return;

        setLoading(true);

        axiosInstance.delete(`wishlist/${item.itemId}`)
            .then(() => {
                setWishlist(wishlist.filter((crt) => crt.itemId !== item.itemId));
            })
            .finally(setLoading(false));
    }

    const markRead = (item) => {
        if (loading) return;

        setLoading(true);

        axiosInstance.patch(`wishlist/${item.itemId}`)
            .then(() => {
                item.status = 1;
            })
            .finally(() => setLoading(false));
    }

    const addWishlistItem = () => {
        if (loading) return;

        setLoading(true);

        axiosInstance.post(`wishlist/user/${currentUser.userId}`,
            newItem)
            .then(({ data }) => {
                const newWishlist = [...wishlist, data];
                setWishlist(newWishlist);
            })
            .finally(() => setLoading(false));
    }

    const getBackground = (item) => {
        if (item.status === 0) {
            return 'secondary';
        }

        return 'success';
    }

    const handleChange = (e) => {
        setNewItem({ ...newItem, [e.target.name]: e.target.value });
    };

    return (
        <>
        <NavMenu />
        {currentUser &&
        <Row className='height-95'>
            <Col xs={9} >
                <Container className='mt-5 mb-3'>
                    <h1 className='text-center mb-5'>Gestionați lista de dorințe</h1>
                    {wishlist.map(item => 
                        <Row className='mb-3' key={item.itemId} style={{fontSize: '1.75em'}}>
                            <Badge bg={getBackground(item)} className='px-4 border-5 d-flex justify-content-between align-middle'>
                                <span>{item.bookTitle} -- {item.authorName}</span>
                                <span>
                                    {item.status === 0 &&
                                    <FontAwesomeIcon role='button' icon={faCheck} className='text-warning mx-2'
                                        onClick={() => { markRead(item) }}
                                    />}
                                    <FontAwesomeIcon role='button' icon={faTrash} className='text-danger'
                                        onClick={() => { deleteItem(item) }} 
                                    />
                                </span>
                            </Badge>
                        </Row>
                    )}
                    <Row>
                        <Col xs={12} md={5}>
                            <Form.Group className="mb-3" >
                                <Form.Control type="text" placeholder="Titlu" 
                                    name="bookTitle" id="bookTitle"
                                    value={newItem.bookTitle}
                                    onChange={handleChange}
                                />
                            </Form.Group>
                        </Col>
                        <Col xs={12} md={5}>
                            <Form.Group className="mb-3" >
                                <Form.Control type="text" placeholder="Autor"
                                    name="authorName" id="authorName"
                                    value={newItem.authorName} 
                                    onChange={handleChange}
                                />
                            </Form.Group>
                        </Col>
                        <Col xs={12} md={2} style={{textAlign: 'right'}}>
                            <Button variant='primary' disabled={loading}
                                onClick={() => {addWishlistItem()}}
                            >
                                Adăugați
                            </Button>
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