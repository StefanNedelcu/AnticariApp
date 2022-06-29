import React, { useEffect, useState } from 'react';
import { Row, Col, Container, Card, Button } from 'react-bootstrap';
import NavMenu from '../NavMenu/NavMenu';
import Profile from '../Profile/Profile'
import ProfileMenu from '../Profile/ProfileMenu';
import BookCard from '../Books/BookCard';
import BookWidget from '../Books/BookWidget';

const Home = () => {
  
  const [currentUser, setCurrentUser] = useState(null);

  useEffect(() => {
    const crtUser = JSON.parse(localStorage.getItem('currentUser'));

    setCurrentUser(crtUser);
  }, [])

  return (
    currentUser &&
    <>
    <NavMenu />
    <Row className='height-95'>
      <Col xs={9}>
        <Container>
          <Row className='mt-3'>
              <h3>Recomandate pentru tine</h3>
              <hr />
          </Row>
          <Row className='d-flex justify-content-between'>
            <Card style={{width: '15rem'}}>
              <div className='text-center'>
              <Card.Img variant="top" src="zlatan.jpg" className='px-3 pt-3 book-card-img' />
              <Card.Body className='text-center'>
                <Card.Title>Eu sunt Zlatan</Card.Title>
                <Card.Text>
                  David Lagercrantz
                </Card.Text>
                <Button variant="dark" style={{width: '100%'}}>30 lei</Button>
              </Card.Body>
              </div>
            </Card>
            <Card style={{width: '15rem'}} >
              <div className='text-center'>
              <Card.Img variant="top" src="ion.jpg" className='px-3 pt-3 book-card-img book-card-img' />
              <Card.Body className='text-center'>
                <Card.Title>Ion</Card.Title>
                <Card.Text>
                  Liviu Rebreanu
                </Card.Text>
                <Button variant="dark" style={{width: '100%'}}>20 lei</Button>
              </Card.Body>
              </div>
            </Card>
            <Card style={{width: '15rem'}}>
              <div className='text-center'>
              <Card.Img variant="top" src="enigma-otiliei.jpg" className='px-3 pt-3 book-card-img' />
              <Card.Body className='text-center'>
                <Card.Title>Enigma Otiliei</Card.Title>
                <Card.Text>
                  Camil Petrescu
                </Card.Text>
                <Button variant="dark" style={{width: '100%'}}>25 lei</Button>
              </Card.Body>
              </div>
            </Card>
            <Card style={{width: '15rem'}}>
              <div className='text-center'>
              <Card.Img variant="top" src="arta-razboiului.jpg" className='px-3 pt-3 book-card-img' />
              <Card.Body className='text-center'>
                <Card.Title>Arta războiului</Card.Title>
                <Card.Text>
                  Sun Tzu
                </Card.Text>
                <Button variant="dark" style={{width: '100%'}}>10 lei</Button>
              </Card.Body>
              </div>
            </Card>
          </Row>
          <Row className='mt-3'>
              <h3>Cele mai noi anunțuri</h3>
              <hr />
          </Row>
          <Row className='d-flex justify-content-between'>
            <Card style={{width: '15rem'}}>
              <div className='text-center'>
              <Card.Img variant="top" src="harry-potter.jpg" className='px-3 pt-3 book-card-img' />
              <Card.Body className='text-center'>
                <Card.Title>Harry Potter</Card.Title>
                <Card.Text>
                  J.K. Rolling
                </Card.Text>
                <Button variant="dark" style={{width: '100%'}}>40 lei</Button>
              </Card.Body>
              </div>
            </Card>
            <Card style={{width: '15rem'}}>
              <div className='text-center'>
              <Card.Img variant="top" src="moarte-pe-nil.jpg" className='px-3 pt-3 book-card-img' />
              <Card.Body className='text-center'>
                <Card.Title>Moarte pe Nil</Card.Title>
                <Card.Text>
                  Agatha Christie
                </Card.Text>
                <Button variant="dark" style={{width: '100%'}}>30 lei</Button>
              </Card.Body>
              </div>
            </Card>
            <Card style={{width: '15rem'}} bg='primary'>
              <div className='text-center'>
              <Card.Img variant="top" src="witcher.jpg" className='px-3 pt-3 book-card-img' />
              <Card.Body className='text-center'>
                <Card.Title>The witcher</Card.Title>
                <Card.Text>
                  Andrzej Sapkowski
                </Card.Text>
                <Button variant="dark" style={{width: '100%'}}>50 lei</Button>
              </Card.Body>
              </div>
            </Card>
            <Card style={{width: '15rem'}}>
              <div className='text-center'>
              <Card.Img variant="top" src="atomic-habits.jpg" className='px-3 pt-3 book-card-img' />
              <Card.Body className='text-center'>
                <Card.Title>Atomic Habits</Card.Title>
                <Card.Text>
                  James Clear
                </Card.Text>
                <Button variant="dark" style={{width: '100%'}}>25 lei</Button>
              </Card.Body>
              </div>
            </Card>
          </Row>
        </Container>
      </Col>
      <Col xs={3} className='side-panel'>
        {/* <Profile userId={currentUser.userId} />
        <ProfileMenu /> */}
        <BookWidget/>
      </Col>
    </Row>
    </>
  );
}

export default Home;
