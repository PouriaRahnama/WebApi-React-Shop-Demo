import React from 'react'
import { Container } from 'react-bootstrap'
import { BrowserRouter as Router, Route, Routes,Navigate } from 'react-router-dom'
import Header from './components/Header/Header'
import Footer from './components/Footer/Footer'
import Home from './pages/Home'
import Product from './pages/Product'
import Search from './pages/Search'
import Cart from './pages/Cart'

const App = () => {
  return (
    <Router>
      <Header />
      <main className="py-3">
        <Container>
          <Routes>
            {/* <Route path="/" element={<Navigate replace to="/Cart" />} /> */}
            <Route path="/" element={<Home />} />
            <Route path="/product/:id" element={<Product />} />
            <Route path="/Category/:title" element={<Search />} />
            <Route path="/Cart/:id?" element={<Cart />} />
            {/* <Route path="/new" element={<p>کاربر جدید</p>} /> */}
          </Routes>
        </Container>
      </main>
      <Footer />
    </Router>
  )
}

export default App