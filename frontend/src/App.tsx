import { Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import Shop from './pages/Shop';
import ProductDetail from './pages/ProductDetail';
import Cart from './pages/Cart';
import Profile from './pages/Profile';
import Login from './pages/Login';
import Signup from './pages/Signup';
import Subscription from './pages/Subscription';
import WishlistPage from './pages/WishlistPage';
import AppLayout from './pages/Applayout';

const App = () => {
  return (
    <>
      <Routes>
        <Route path="/" element={<AppLayout />} >
          <Route path="/shop" element={<Shop />} />
          <Route path="/product/:id" element={<ProductDetail />} />
          <Route path="/wishlist" element={<WishlistPage />} />
          <Route path="/cart" element={<Cart />} />
          <Route path="/profile" element={<Profile />} />
          <Route path="/login" element={<Login />} />    
          <Route path="/signup" element={<Signup />} /> 
          <Route path="/subscription" element={<Subscription />} />
        </Route>
      </Routes>
    </>
  );
};

export default App;
