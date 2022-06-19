import React from "react"
import { Route, Redirect } from "react-router-dom"

const PrivateRoute = ({ component: Component, ...rest }) => {

  return (
    <Route
      {...rest}
      render={props => {
        return localStorage.getItem('currentUser') ? <Component {...props} /> : <Redirect to="/login" />
      }}
    ></Route>
  )
}

export default PrivateRoute;