import React from "react";
import { Outlet } from "react-router-dom";
import Nav from "../components/Nav";
import Footer from "../components/Footer";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { jwtDecode } from "jwt-decode";

const AppLayout: React.FC = () => {
  const navigate = useNavigate();

  const isLoggedIn = () => {
    const token = localStorage.getItem("jwtToken");
    if (!token) {
      return false;
    }
    try {
      const decodedToken = jwtDecode(token);
      if (decodedToken.exp && decodedToken.exp * 1000 < Date.now()) {
        localStorage.removeItem("jwtToken");
        return false;
      }
      return true;
    } catch (error) {
      return false;
    }
  };

  useEffect(() => {
    if (!isLoggedIn()) {
      navigate("/login");
    }
  }, [navigate]);

  return (
    <div>
      <Nav />
      <main>
        <Outlet />
      </main>
      <Footer />
    </div>
  );
};

export default AppLayout;
