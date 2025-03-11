import React, {useEffect, useState} from 'react';
import ProductTable from './Components/ProductTable.jsx';
import ProductInput from './Components/ProductInput.jsx';
import ProductUpdate from './Components/ProductUpdate.jsx';
import ChartTotalStockByCategory from "./Components/ChartTotalStockByCategory.jsx";
import ChartTotalProductsAddedByTime from "./Components/ChartTotalProductsAddedByTime.jsx";
import './App.css'
import axios from "axios";


function App() {

    const [selectedProduct, setSelectedProduct] = useState(null);
    const [reload, setReload] = useState(false);
    const [categories, setCategories] = useState([]);
    const [stockQtyData, setStockQtyData] = useState([]);
    const [productsAddedData, setProductsAddedData] = useState([]);

    const handleProductUpdated = () => {
        setReload((prev) => !prev);
    };

    useEffect(() => {

        const fetchCategories = async () => {
            try {
                const response = await axios.get('http://localhost:5179/productcategories');
                setCategories(response.data);
            } catch (error) {
                console.error('Error fetching categories:', error);
            }
        };

        const fetchStockQtyData = async () => {
            try {
                const response = await axios.get('http://localhost:5179/chartdata/stockquantitybycategory');
                setStockQtyData(response.data);
            } catch (error) {
                console.error('Error fetching stock qty data:', error);
            }
        };

        const fetchProductsAddedData = async () => {
            try {
                const response = await axios.get('http://localhost:5179/chartdata/productsadded');
                setProductsAddedData(response.data);
            } catch (error) {
                console.error('Error fetching stock qty data:', error);
            }
        };

        fetchCategories();
        fetchStockQtyData();
        fetchProductsAddedData();
    }, []);

  return (
    <>
        <div className="App">
            <div className="row">
                <div className="col-12 col-lg-6">
                    <div className="alert alert-light">
                        <h4>Product List</h4>
                        <hr />
                        <ProductTable setSelectedProduct={setSelectedProduct} reload={reload}/>
                    </div>
                </div>
                <div className="col-12 col-lg-3">
                    <div className="alert alert-info">
                        <h4>Update product</h4>
                        <hr />
                        <ProductUpdate categories={categories} product={selectedProduct} onProductUpdated={handleProductUpdated} />
                    </div>
                </div>
                <div className="col-12 col-lg-3">
                    <div className="alert alert-info">
                        <h4>Create product</h4>
                        <hr />
                        <ProductInput categories={categories} onProductCreated={handleProductUpdated}/>
                    </div>
                </div>
            </div>
            <div className="row">
                <div className="col-12 col-lg-4">
                    <ChartTotalStockByCategory data={stockQtyData} />
                </div>
                <div className="col-12 col-lg-4">
                    <ChartTotalProductsAddedByTime data={productsAddedData}  />
                </div>
            </div>
        </div>
    </>
  )
}

export default App
