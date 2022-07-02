import React, { useState, useEffect } from 'react';
import { Row, Col, Container, Card, Form, Button } from 'react-bootstrap';
import axiosInstance from '../../config/Axios';
import NavMenu from '../NavMenu/NavMenu';
import BookCard from '../Books/BookCard';
import Profile from '../Profile/Profile';
import ProfileMenu from '../Profile/ProfileMenu';
import BookWidget from '../Books/BookWidget';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

const Search = () => {
    const [loading, setLoading] = useState(true);
    const [currentUser, setCurrentUser] = useState(null);
    const [postings, setPostings] = useState([]);
    const [selectedPosting, setSelectedPosting] = useState(null);
    const [filter, setFilter] = useState({
        query: ''
    })

    useEffect(() => {
        const crtUser = JSON.parse(localStorage.getItem('currentUser'));

        setCurrentUser(crtUser);

        setLoading(false);
    }, [])

    const searchPostings = () => {
        setLoading(true);

        axiosInstance.get(`posting/search?query=${filter.query}`)
            .then(({ data }) => {
                setPostings(data)
            })
            .finally(() => setLoading(false));
    }

    const selectPosting = (item) => {
        if (item.postingId === selectedPosting?.postingId)
        {
          setSelectedPosting(null);
          return;
        }
    
        setSelectedPosting(item)
      }

    const handleChange = (e) => {
        setFilter({ ...filter, [e.target.name]: e.target.value });
    };

    return (
        <>
        <NavMenu />
        {!loading &&
        <Row className='height-95'>
            <Col xs={9}>
                <Container>
                    <Row className='mt-3'>
                        <h3>Căutați printre postările existente</h3>
                        <hr />
                    </Row>
                    <Row>
                        <Form onSubmit={searchPostings}>
                            <div className='d-flex'>
                            <Form.Group style={{width: '90%'}}>
                                <Form.Control type="text" name="query" id="query"
                                    value={filter.query}
                                    onChange={handleChange}
                                    placeholder='Titlu, autor sau categorie...'
                                    required
                                />
                            </Form.Group>
                            <Button variant='success' disabled={loading} type="submit" style={{width: '10%'}}>
                                <FontAwesomeIcon role='button' icon={faSearch} />
                            </Button>
                            </div>
                        </Form>
                    </Row>
                    <Row className='mt-5 d-flex'>            
                        {postings.map(item => 
                        <Card style={{width: '15rem'}} 
                            className={(selectedPosting?.postingId === item.postingId ? 'bg-primary shadow mx-4' : 'bg-light shadow mx-4')}
                            onClick={() => selectPosting(item)}
                            key={item.postingId}
                        >
                            <BookCard 
                            posting={item}
                            />
                        </Card>
                        )}
                    </Row>
                </Container>
            </Col>
            <Col xs={3} className='side-panel'>
                {!selectedPosting ?
                <>
                <Profile userId={currentUser.userId} />
                <ProfileMenu />
                </> :
                <BookWidget posting={selectedPosting}/>}
            </Col>
        </Row>}
        </>
    )
}

export default Search;
