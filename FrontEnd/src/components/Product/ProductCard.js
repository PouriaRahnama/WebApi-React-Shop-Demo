import React from 'react'
import { Link } from 'react-router-dom'
import { Card } from 'react-bootstrap'


const ProductCard = ({ product }) => {
  return (
    <Card className="my-3 p-3 rounded">
      <Link to={`/product/${product.productId}`}>
        <Card.Img src={product.imageURL} variant="top" />        
      </Link>

      <Card.Body>
        <Link to={`/product/${product.productId}`}>
          <Card.Title as="div">{product.name}</Card.Title>
        </Link>       
      </Card.Body>

      <Card.Text as="h3">{product.price}</Card.Text>
    </Card>
    
  )
}

export default ProductCard
