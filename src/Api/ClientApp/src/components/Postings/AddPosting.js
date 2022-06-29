import React, { useEffect, useState } from 'react';
import { Container, Row, Col, Form, Button } from 'react-bootstrap';
import NavMenu from '../NavMenu/NavMenu';
import Profile from '../Profile/Profile';
import ProfileMenu from '../Profile/ProfileMenu';
import axiosInstance from '../../config/Axios';

const AddPosting = () => {
    const [currentUser, setCurrentUser] = useState(null);
    const [posting, setPosting] = useState({
        userId: 0,
        title: '',
        author: '',
        category: '',
        thumbnail: '',
        publisher: '',
        price: 0,
        description: ''
    });
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const crtUser = JSON.parse(localStorage.getItem('currentUser'));

        setCurrentUser(crtUser);
        posting.userId = crtUser.userId;

        setLoading(false);
    }, [])

    const handleChange = (e) => {
        setPosting({ ...posting, [e.target.name]: e.target.value });
    };

    const handleSubmit = () => {
        setLoading(true);        
        
        axiosInstance.post('posting', posting)
            .then(() => setLoading(false))
            .finally(() => setLoading(false));
    }

    return (
        <>
        <NavMenu />
        {currentUser &&
        <Row className='height-95'>
            <Col xs={9}>
                <Container className='mt-5'>
                    <h1 className='text-center'>Adăugați o postare nouă!</h1>
                    <Form className='mt-5' onSubmit={handleSubmit} >
                        <Container>
                        <Row className='mt-2'>                    
                            <Col xs={12} md={6}>
                                <Form.Group>
                                    <Form.Label style={{fontWeight: 'bold'}} htmlFor="title">Titlu</Form.Label>
                                    <Form.Control type="text" name="title" id="title"
                                        value={posting.title}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>
                            </Col>
                            <Col xs={12} md={6}>
                                <Form.Group>
                                    <Form.Label style={{fontWeight: 'bold'}} htmlFor="author">Autor</Form.Label>
                                    <Form.Control type="text" name="author" id="author"
                                        value={posting.author}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>
                            </Col>
                        </Row>
                        <Row className='mt-2'>                                
                            <Col xs={12} md={6}>
                                <Form.Group>
                                    <Form.Label style={{fontWeight: 'bold'}} htmlFor="category">Gen</Form.Label>
                                    <Form.Control type="text" name="category" id="category"
                                        value={posting.category}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>
                            </Col>
                            <Col xs={12} md={6}>
                                <Form.Group>
                                    <Form.Label style={{fontWeight: 'bold'}} htmlFor="thumbnail">Thumbnail URL</Form.Label>
                                    <Form.Control type="text" name="thumbnail" id="thumbnail"
                                        value={posting.thumbnail}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>
                            </Col>
                        </Row>
                        <Row className='mt-2'>                                
                            <Col xs={12} md={6}>
                                <Form.Group>
                                    <Form.Label style={{fontWeight: 'bold'}} htmlFor="publisher">Editura</Form.Label>
                                    <Form.Control type="text" name="publisher" id="publisher"
                                        value={posting.publisher}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>
                            </Col>
                            <Col xs={12} md={6}>
                                <Form.Group>
                                    <Form.Label style={{fontWeight: 'bold'}} htmlFor="price">Preț (RON)</Form.Label>
                                    <Form.Control type="number" name="price" id="price"
                                        value={posting.price}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>
                            </Col>
                        </Row>
                        <Row className='mt-2'>                                
                            <Col xs={12}>
                                <Form.Group>
                                    <Form.Label style={{fontWeight: 'bold'}} htmlFor="description">Descriere</Form.Label>
                                    <Form.Control as="textarea" rows={3} name="description" id="description"
                                        value={posting.description}
                                        onChange={handleChange}
                                        required
                                    />
                                </Form.Group>
                            </Col>
                        </Row>             
                        <Row>
                            <Button variant='primary' disabled={loading} type="submit" className='mt-3'>
                                Publică anunț
                            </Button>
                        </Row>
                        </Container>
                    </Form>
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

export default AddPosting;
