import React from 'react';
import { Button } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import axiosInstance from "../../config/Axios";

const ProfileMenu = () => {
    const history = useHistory();

    async function logout() {
        await axiosInstance.get('auth')
            .then(() => { 
                localStorage.clear();
            })
            .finally(() => history.push('/login'));
    }
    
    function goToEditProfile() {
        history.push(`settings`);
    }

    return (
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
    );
}

export default ProfileMenu;
