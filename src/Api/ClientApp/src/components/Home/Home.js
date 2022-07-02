import React, { useEffect, useState } from 'react';
import { Row, Col, Container, Card } from 'react-bootstrap';
import NavMenu from '../NavMenu/NavMenu';
import Profile from '../Profile/Profile'
import ProfileMenu from '../Profile/ProfileMenu';
import BookCard from '../Books/BookCard';
import BookWidget from '../Books/BookWidget';
import axiosInstance from '../../config/Axios';

const Home = () => {  
  const [currentUser, setCurrentUser] = useState(null);
  const [homepage, setHomepage] = useState({
    recommendations: [],
    latest: []
  })
  const [selectedPosting, setSelectedPosting] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const crtUser = JSON.parse(localStorage.getItem('currentUser'));

    setCurrentUser(crtUser);
    getPage(crtUser.userId);
    setLoading(false);
  }, [])

  const getPage = (userId) => {
    setLoading(true);

    axiosInstance.get(`posting/user/${userId}`)
      .then(({ data }) => {
        setHomepage(data)
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

  return (    
    <>
    <NavMenu />
    {currentUser && !loading &&
    <Row className='height-95'>
      <Col xs={9}>
        <Container>
          <Row className='mt-3'>
              <h3>Recomandate pentru tine</h3>
              <hr />
          </Row>
          <Row className='d-flex justify-content-between'>            
            {homepage.recommendations.map(item => 
              <Card style={{width: '15rem'}} 
                className={(selectedPosting?.postingId === item.postingId ? 'bg-primary shadow' : 'bg-light shadow')}
                onClick={() => selectPosting(item)}
                key={item.postingId}
              >
                <BookCard 
                  posting={item}
                />
              </Card>
            )}
          </Row>
          <Row className='mt-3'>
              <h3>Cele mai noi anunțuri</h3>
              <hr />
          </Row>
          <Row className='d-flex justify-content-between'>
            {homepage.latest.map(item =>
              <Card style={{width: '15rem'}} 
                className={(selectedPosting?.postingId === item.postingId ? 'bg-primary shadow' : 'bg-light shadow')}
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
  );
}

export default Home;
