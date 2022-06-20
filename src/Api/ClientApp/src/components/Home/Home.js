import React, { useEffect, useState } from 'react';
import axiosInstance from "../../config/Axios";
import { Row, Col } from 'react-bootstrap';
import NavMenu from '../NavMenu/NavMenu';
import Profile from '../Profile/Profile'

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
        Salut
      </Col>
      <Col xs={3} className='side-panel'>
        <Profile userId={currentUser.userId} />
      </Col>
    </Row>
    </>
  );
}

export default Home;
