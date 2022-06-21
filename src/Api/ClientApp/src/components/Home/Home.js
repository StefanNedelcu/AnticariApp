import React, { useEffect, useState } from 'react';
import { useHistory } from "react-router-dom";
import axiosInstance from "../../config/Axios";
import { Row, Col, Button } from 'react-bootstrap';
import NavMenu from '../NavMenu/NavMenu';
import Profile from '../Profile/Profile'

const Home = () => {
  const history = useHistory();
  const [currentUser, setCurrentUser] = useState(null);

  useEffect(() => {
    const crtUser = JSON.parse(localStorage.getItem('currentUser'));

    setCurrentUser(crtUser);
  }, [])

  async function logout() {
    await axiosInstance.get('auth')
        .then(() => { 
            localStorage.clear();
        })
        .finally(() => history.push('/login'));
  }

  function goToEditProfile() {
    history.push(`profile/${currentUser.userId}`);
  }

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
        <div className='mt-4 text-center'>
          <Button variant="light" size='sm' className='mx-2'
              onClick={goToEditProfile}>
              Editați
          </Button>

          <Button variant="light" size='sm' className='mx-2'
              onClick={logout}>
              Logout
          </Button>
        </div>
      </Col>
    </Row>
    </>
  );
}

export default Home;
